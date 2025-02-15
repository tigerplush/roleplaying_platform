# Custom Online Roleplay Gaming Interface

## Goals
1. Easy handling of characters
2. Easy support for custom roleplaying systems
3. Full container support (best case: one command to start the whole thing)
4. Discord integration
5. Printable/exportable character sheets (PDF)

## Running the project

Currently (15FEB2025) you can use `docker-compose up` to start all containers. Backend and Frontend are misconfigured, so they might crash.
If you manually stop Backend and Frontend, you can login into keycloak (`http://localhost:8080`), create a new realm, activate user registration in realm settings,
add `+` to Web origins in Clients/account-console, add `http://localhost:4200/*` to Valid redirect URIs and then start the angular project within `Corgi.Frontend/` with `npm install`
and `ng serve`.

You might have to call `npm install -g @angular/cli` once in order to install the angular cli that provides `ng`. You also have to install nodejs.org (I recommend on windows to install it via the Windows installer .msi, not fnm)

## Keycloak Setup

1. In clients/account-console/Client scopes, click on account-console-dedicated
    1. Add 'client coles' to the mappers and add 'default-roles-corgi' to the scope

I'm very unsure how this should be configured correctly, but for now it works.