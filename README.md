# AuthCenter
Centralized authentication and authorization service for multi-tenant .NET applications — built with OpenIddict, OAuth2, and OpenID Connect.

🏷️ AuthCenter

AuthCenter is a standalone identity and access management service designed to provide secure authentication, authorization, and multi-tenant identity control for modern .NET applications — starting with the Restaurant Management System (RMS).

Built on OAuth 2.0 and OpenID Connect (OIDC) using OpenIddict, AuthCenter acts as the central identity provider (Authorization Server) for all client applications — React frontends, APIs, and administrative dashboards.

🔐 Key Features

✅ Full OAuth2 + OIDC support

✅ Multi-tenant architecture (organizations, apps, custom domains)

✅ MFA (TOTP, Email, SMS) ready design

✅ User management via ASP.NET Identity

✅ Token-based security (access, refresh, ID tokens)

✅ Extensible for SSO and federated login in the future

🧠 Purpose

AuthCenter separates identity and access control from business logic to ensure:

Reusability across multiple RMS modules and external apps

Security isolation (dedicated Auth DB)

Scalability — can evolve into a general IAM (Identity & Access Management) system

⚙️ Tech Stack

.NET 8 — core framework

OpenIddict — OAuth2 + OIDC implementation

ASP.NET Identity — user and role management

Entity Framework Core — database persistence

React (PKCE flow) — frontend clients

PostgreSQL / SQL Server — identity data storage

🧩 High-Level Architecture
React App  ──► AuthCenter (OpenIddict)
                 │
                 ├── Issues tokens (Access + ID)
                 │
                 ▼
          RMS API (validates JWT)
                 │
                 ▼
             Tenant Data

🚀 Planned Roadmap

Phase 1: OAuth2 + OIDC flows with OpenIddict

Phase 2: Tenant-aware identity + token claims

Phase 3: MFA (TOTP / Email / SMS)

Phase 4: BFF pattern for secure React integration

Phase 5: Admin UI for tenants, roles, and users

📘 Mission Statement

AuthCenter aims to be a secure, extensible, and developer-friendly identity hub that unifies authentication and authorization across all RMS applications and future .NET systems.
