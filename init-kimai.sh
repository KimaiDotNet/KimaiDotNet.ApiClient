#!/bin/sh
# Initialises the local Kimai test instance with a known admin user, API token,
# and deterministic seed data for integration tests.
#
# Runs once as the kimai-init service in docker-compose.yml.
#
# After this script completes the following are available:
#   URL:        http://localhost:8001
#   User:       kimai-admin / Admin1234!
#   Token:      kimai-local-integration-test-token
#
#   Seeded IDs (auto-increment starts at 1 on a fresh database):
#     Customer ID:     1  ("Test Customer")
#     Project  ID:     1  ("Test Project")
#     Activity ID:     1  ("Test Activity")
#
# To run integration tests locally:
#   docker compose up -d
#   # Wait for kimai-init to print "Kimai test environment ready"
#   dotnet test --filter "Category=Integration"

set -e

CONSOLE="/opt/kimai/bin/console"
API_TOKEN="kimai-local-integration-test-token"
BASE_URL="http://kimai:8001"

# ---------------------------------------------------------------------------
# 1. Admin user
# ---------------------------------------------------------------------------
echo "==> Creating admin user..."
if $CONSOLE kimai:user:create kimai-admin admin@kimai.local ROLE_SUPER_ADMIN 'Admin1234!'; then
    echo "    User created."
else
    echo "    User already exists, resetting password..."
    $CONSOLE kimai:user:password kimai-admin -- 'Admin1234!'
fi

# ---------------------------------------------------------------------------
# 2. API token (inserted directly – the console command was added in Kimai 2.1)
# ---------------------------------------------------------------------------
echo "==> Inserting API token..."
$CONSOLE dbal:run-sql \
    "INSERT INTO kimai2_access_token (user_id, token, name) \
     SELECT id, '${API_TOKEN}', 'integration-test' FROM kimai2_users \
     WHERE username = 'kimai-admin' \
     ON DUPLICATE KEY UPDATE token = '${API_TOKEN}'" \
    --no-interaction

# ---------------------------------------------------------------------------
# 3. Seed test data via the API
# ---------------------------------------------------------------------------
echo "==> Seeding test data..."

CUSTOMER=$(curl -sf -X POST "${BASE_URL}/api/customers" \
  -H "Authorization: Bearer ${API_TOKEN}" \
  -H "Content-Type: application/json" \
  -d '{"name":"Test Customer","currency":"USD","timezone":"UTC","country":"US","visible":true}')
CUSTOMER_ID=$(echo "${CUSTOMER}" | grep -o '"id":[0-9]*' | head -1 | grep -o '[0-9]*')
echo "    Customer id=${CUSTOMER_ID}"

PROJECT=$(curl -sf -X POST "${BASE_URL}/api/projects" \
  -H "Authorization: Bearer ${API_TOKEN}" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Test Project\",\"customer\":${CUSTOMER_ID},\"visible\":true}")
PROJECT_ID=$(echo "${PROJECT}" | grep -o '"id":[0-9]*' | head -1 | grep -o '[0-9]*')
echo "    Project  id=${PROJECT_ID}"

ACTIVITY=$(curl -sf -X POST "${BASE_URL}/api/activities" \
  -H "Authorization: Bearer ${API_TOKEN}" \
  -H "Content-Type: application/json" \
  -d "{\"name\":\"Test Activity\",\"project\":${PROJECT_ID},\"visible\":true}")
ACTIVITY_ID=$(echo "${ACTIVITY}" | grep -o '"id":[0-9]*' | head -1 | grep -o '[0-9]*')
echo "    Activity id=${ACTIVITY_ID}"

echo ""
echo "============================================================"
echo "  Kimai test environment ready."
echo ""
echo "  URL:   http://localhost:8001"
echo "  User:  kimai-admin / Admin1234!"
echo "  Token: ${API_TOKEN}"
echo ""
echo "  Seeded data:"
echo "    Customer ID: ${CUSTOMER_ID}"
echo "    Project ID:  ${PROJECT_ID}"
echo "    Activity ID: ${ACTIVITY_ID}"
echo ""
echo "  Run integration tests:"
echo "    dotnet test --filter \"Category=Integration\""
echo "============================================================"
