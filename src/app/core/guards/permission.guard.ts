import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { PermissionService } from '../services/permission.service';
import { UserRolesEnum } from '../enums/user-role.enum';
import { AppPermissionsEnum } from '../enums/app-permissions.enum';
import { unauthorizedRoutePath } from '../../base/routes/app.routes';

@Injectable({
  providedIn: 'root',
})
export class PermissionGuard implements CanActivate {
  constructor(
    private _permissionsService: PermissionService, 
    private _router: Router
  ) {}


  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const requiredPermission = route.data['permission'] as AppPermissionsEnum;
    
    if (requiredPermission && !this._permissionsService.hasPermission(requiredPermission)) {
      this._router.navigate(['/', unauthorizedRoutePath]); // Navigate to unauthorized page
      return false;
    }

    return true;
  }
}