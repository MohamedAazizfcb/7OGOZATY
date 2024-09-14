import { baseEnvironment } from "./base-environment";

export const environment = {
    ...baseEnvironment,
    production: false,
    apiUrl: 'https://api.production.example.com', // base url for APIs
    logging: false, // allow logging
    featureFlag: true, // run experimental features
};