# CuraFlow backend API

The API controllers dispatch application requests through MediatR. Resource routes
use the `/api` prefix; token routes use `/identity/token`, matching the frontend
service URLs.

## Endpoints

| Method | Route | Description | Request |
|---|---|---|---|
| `POST` | `/api/appointments` | Create an appointment | `PatientId`, `DoctorId`, `MedicalDepartmentId`, `AppointmentDate` |
| `GET` | `/api/appointments/{id}` | Get an appointment | — |
| `GET` | `/api/appointments` | List/filter appointments | Query: `Page`, `PageSize`, `SearchTerm`, `SortColumn`, `SortDirection`, `Status`, `PatientId`, `DoctorId`, `StartDateFrom`, `StartDateTo`, `EndDateFrom`, `EndDateTo` |
| `PATCH` | `/api/appointments/schedule/{id}` | Reschedule an appointment | `NewAppointmentDate` |
| `PATCH` | `/api/appointments/update-status/{id}` | Change appointment status | `NewStatus` |
| `DELETE` | `/api/appointments/{id}` | Delete an appointment | — |
| `POST` | `/api/visits` | Create a visit and optional prescriptions | `MedicalRecordId`, `DepartmentId`, `DoctorId`, `Diagnosis`, `ChiefComlaint`, `Symptoms`, `VisitDate`, `Prescriptions` |
| `GET` | `/api/visits` | List visits | — |
| `GET` | `/api/visits/{id}` | Get a visit | — |
| `PUT` | `/api/visits/{id}` | Update a visit and optional prescriptions | `Diagnosis`, `ChiefComlaint`, `Symptoms`, `Prescriptions` |
| `DELETE` | `/api/visits/{id}` | Delete a visit | — |
| `POST` | `/api/invoices` | Create an invoice | `TreatmentId` |
| `GET` | `/api/invoices/{id}` | Get an invoice | — |
| `POST` | `/api/invoices/{id}/settle` | Settle an invoice | — |
| `POST` | `/api/medicines` | Create a medicine | `Name`, `Price` |
| `GET` | `/api/medicines` | List medicines | — |
| `GET` | `/api/medicines/{id}` | Get a medicine | — |
| `PUT` | `/api/medicines/{id}` | Update a medicine | `Name`, `Price` |
| `DELETE` | `/api/medicines/{id}` | Delete a medicine | — |
| `POST` | `/api/patients` | Create a patient | `FirstName`, `Lastname`, `Phone`, `Email` |
| `GET` | `/api/patients` | List patients | — |
| `GET` | `/api/patients/{id}` | Get a patient | — |
| `PUT` | `/api/patients/{id}` | Update a patient | `FirstName`, `LastName`, `Phone`, `Email` |
| `DELETE` | `/api/patients/{id}` | Delete a patient | — |
| `POST` | `/api/treatments` | Create a treatment | `TreatmentName`, `TreatmentDescription`, `Price`, `DiscountAmount`, `Medicines` |
| `GET` | `/api/treatments` | List treatments | — |
| `GET` | `/api/treatments/{id}` | Get a treatment | — |
| `PUT` | `/api/treatments/{id}` | Update a treatment | `TreatmentName`, `TreatmentDescription`, `Price`, `DiscountAmount`, `Medicines` |
| `DELETE` | `/api/treatments/{id}` | Delete a treatment | — |
| `POST` | `/api/employees` | Create an employee | `FirstName`, `LastName`, `Address`, `PhoneNumber`, `Email`, `Role` |
| `GET` | `/api/employees/{id}` | Get employee credentials | — |
| `PUT` | `/api/employees/{id}` | Update an employee | `FirstName`, `LastName`, `Address`, `PhoneNumber`, `Email`, `Role` |
| `DELETE` | `/api/employees/{id}` | Remove an employee | — |
| `POST` | `/api/medical-departments` | Create a medical department | `Name`, `BaseConsultationFee`, `DefualtDurationMinutes`, `Description` |
| `GET` | `/api/medical-departments` | List medical departments | — |
| `GET` | `/api/medical-departments/{id}` | Get a medical department | — |
| `PUT` | `/api/medical-departments/{id}` | Update a medical department | `Name`, `BaseConsultationFee`, `DefualtDurationMinutes`, `Description` |
| `DELETE` | `/api/medical-departments/{id}` | Delete a medical department | — |
| `POST` | `/api/medical-records` | Create a medical record | `PatientId`, `BloodType`, `Allergies`, `ChronicDiseases`, `SurgicalHistory`, `FamilyHistory` |
| `GET` | `/api/medical-records` | List medical records | — |
| `GET` | `/api/medical-records/{id}` | Get a medical record | — |
| `PUT` | `/api/medical-records/{id}` | Update a medical record | `BloodType`, `Allergies`, `ChronicDiseases`, `SurgicalHistory`, `FamilyHistory` |
| `DELETE` | `/api/medical-records/{id}` | Delete a medical record | — |
| `POST` | `/identity/token/generate` | Generate an access/refresh token pair | `Email`, `Password` |
| `POST` | `/identity/token/refresh` | Refresh an access/refresh token pair | `RxpiredAccessToken`, `RefreshToken` |

Identifiers in `{id}` are GUIDs. For update and appointment actions, the route
identifier is authoritative; clients do not need to include it in the request
body. Request fields and enum values follow the corresponding application
command types. Error results are converted to validation/problem responses by
the shared API controller.

The controllers define the HTTP-to-MediatR boundary. Request handlers for these
features are not currently present in the application, so the endpoints need
those handlers before they can execute successfully.