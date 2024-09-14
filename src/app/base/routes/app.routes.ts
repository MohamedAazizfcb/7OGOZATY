import { Route, Routes } from '@angular/router';
import { authenticationRoutingObject }  from '../../features/authentication/authentication-routing';
import { RouteInfoModel } from '../../core/models/route-info.model';
import { NotFoundComponent } from '../../core/components/not-found/not-found.component';
import { UnauthorizedComponent } from '../../core/components/unauthorized/unauthorized.component';
import { UserRolesEnum } from '../../core/enums/user-role.enum';
import { AppPermissionsEnum } from '../../core/enums/app-permissions.enum';
import { PermissionGuard } from '../../core/guards/permission.guard';


const generateRoutesFromRoutingModel = (routingModel:  { [key : string]: RouteInfoModel }): Routes => {
    const routeInfoArray: RouteInfoModel[] = Object.values(routingModel);
    return routeInfoArray.map(
        (routeInfo: RouteInfoModel): Route => {
            return routeInfo.routingObject;
        }
    );
};

export const unauthorizedRoutePath: string = 'unauthorized'


export const routes: Routes = [
    {  
        path: authenticationRoutingObject.parentRoute, 
        children: generateRoutesFromRoutingModel(authenticationRoutingObject.routes) 
    },
    { 
        path: unauthorizedRoutePath, 
        component: UnauthorizedComponent, 
    },
    { 
        path: '', 
        redirectTo: unauthorizedRoutePath, 
        pathMatch: 'full'
    },
    { 
        path: '**', 
        component: NotFoundComponent,
        pathMatch: 'full'
    }
];

        // data:{permission: AppPermissionsEnum.EditProfile},
