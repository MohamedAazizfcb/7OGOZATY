import { Injectable } from '@angular/core';
import { UserRolesEnum } from '../enums/user-role.enum';
import { AppPermissionsEnum } from '../enums/app-permissions.enum';
import { USER_ROLE_PERMISSIONS } from '../constants/user-role-permissions.const';

@Injectable({
  providedIn: 'root'
})
export class PermissionService {
  private _currentUserRole: UserRolesEnum = UserRolesEnum.Guest; // Default to Guest

  constructor() {}

  private fillCustomUserRolePermissions = (rolePremissions: AppPermissionsEnum[]): void=>{
    for(let permission of rolePremissions)
    {
      USER_ROLE_PERMISSIONS.Custom.push(permission);
    }
  }

  // Check if the user has a specific permission
  hasPermission = (permission: AppPermissionsEnum): boolean => {
    return USER_ROLE_PERMISSIONS[this._currentUserRole].includes(permission);
  }

  // Set the current user role
  setUserRole = (role: UserRolesEnum, rolePremissions?: AppPermissionsEnum[]): void => {
    this._currentUserRole = role;
    if(this._currentUserRole == UserRolesEnum.Custom)
    {
      this.fillCustomUserRolePermissions(rolePremissions??[]);
    }
  }

  // Get the current user role
  getUserRole = (): UserRolesEnum =>{
    return this._currentUserRole;
  }
}