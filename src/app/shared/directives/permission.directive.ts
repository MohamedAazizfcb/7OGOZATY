import { Directive, Input, TemplateRef, ViewContainerRef } from '@angular/core';
import { PermissionService } from '../../core/services/permission.service';
import { AppPermissionsEnum } from '../../core/enums/app-permissions.enum';

@Directive({
  selector: '[appHasPermission]',
  standalone: true
})
export class HasPermissionDirective {
    constructor(
        private _templateRef: TemplateRef<any>,
        private _viewContainer: ViewContainerRef,
        private _permissionService: PermissionService
      ) {}

    @Input() set appHasPermission(permission: AppPermissionsEnum) {
        if (this._permissionService.hasPermission(permission)) 
        {
            this._viewContainer.createEmbeddedView(this._templateRef);
        } 
        else 
        {
            this._viewContainer.clear();
        }
    }
}
