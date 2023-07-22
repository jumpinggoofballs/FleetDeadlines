# Fleet Deadlines with DVLA
A CSharp WebApp Demo (with Razor Pages)

1. Add your vehicles to your "Fleet" by getting their details from the DVLA api
2. Get a list of upcoming MOT and Tax deadlines, in order - closest deadlines at the top

## Next Steps
- Connect to a real database
- Add user authentication + per user(group) Fleets
- Make the layout responsive / mobile friendly
- Add / enable branding

## API keys and `.env` layout
```
TEST_API=https://uat.driver-vehicle-licensing.api.gov.uk/vehicle-enquiry/v1/vehicles
TEST_KEY=[personalKey]
REAL_API=https://driver-vehicle-licensing.api.gov.uk/vehicle-enquiry/v1/vehicles
REAL_KEY=[personalKey]
```
