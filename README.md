<h1 align="center">Rusell API</h1>
<p align="center">This project is a simple API oriented to microservices that allows the management of transport companies operations.</p>
<br/>
<p align="center">
    <br/>
    <a href="https://github.com/cantte/Rusell.Api"><img src="https://github.com/cantte/Rusell.Api/actions/workflows/dotnet.yml/badge.svg" alt="Build Status" /></a>
    <a href="https://codecov.io/gh/cantte/Rusell.Api"><img src="https://codecov.io/gh/cantte/Rusell.Api/branch/main/graph/badge.svg?token=M4zDvKX10h" alt="Build Status" /></a>
</p>

## Getting Started

Make sure you have installed and configured docker and kubernetes. After that, you can run the following command to
start the API:

```shell
./deploy.sh
```

This will create a new kubernetes deployment and service for the API.

## Features
- `Addresses.Api` - Addresses API
- `BankDrafts.Api` - Bank Drafts API
- `Client.Api` - Clients API
- `Companies.Api` - Companies API
- `Employees.Api` - Employees API
- `Parcels.Api` - Parcels API
- `Routes.Api` - Routes API
- `Tickets.Api` - Tickets API
- `TransportSheets.Api` - Transport Sheets API
- `VehiCles.Api` - Vehicles API
