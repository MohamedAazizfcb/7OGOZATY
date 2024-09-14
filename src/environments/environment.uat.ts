import { baseEnvironment } from "./base-environment";

export const environment = {
    ...baseEnvironment,
    production: false,
    apiUrl: 'https://api.uat.example.com', // base url for APIs
    logging: true, // allow logging
    featureFlag: true, // run experimental features
};