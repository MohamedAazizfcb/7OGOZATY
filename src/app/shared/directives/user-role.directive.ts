import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { PermissionService } from '../../core/services/permission.service';
import { AppPermissionsEnum } from '../../core/enums/app-permissions.enum';
import { UserRolesEnum } from '../../core/enums/user-role.enum';

@Directive({
  selector: '[appHasUserRole]',
  standalone: true
})
export class HasUserRoleDirective {
    constructor(
        private _templateRef: TemplateRef<any>,
        private _viewContainer: ViewContainerRef,
        private _permissionService: PermissionService
      ) {}

    @Input() set appHasUserRole(userRole: UserRolesEnum) {
        if (this._permissionService.getUserRole() == userRole) 
        {
            this._viewContainer.createEmbeddedView(this._templateRef);
        } 
        else 
        {
            this._viewContainer.clear();
        }
    }
}
