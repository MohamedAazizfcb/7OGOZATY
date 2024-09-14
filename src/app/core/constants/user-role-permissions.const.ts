import { AppPermissionsEnum } from "../enums/app-permissions.enum";
import { UserRolesEnum } from "../enums/user-role.enum";

export const USER_ROLE_PERMISSIONS: Record<UserRolesEnum, AppPermissionsEnum[]> = {
    [UserRolesEnum.Admin]: [
        AppPermissionsEnum.ViewDashboard, 
        AppPermissionsEnum.EditProfile, 
        AppPermissionsEnum.ManageUsers
    ],
    [UserRolesEnum.User]: [
        AppPermissionsEnum.ViewDashboard, 
        AppPermissionsEnum.EditProfile
    ],
    [UserRolesEnum.Guest]: [],
    [UserRolesEnum.Custom]: [],
};