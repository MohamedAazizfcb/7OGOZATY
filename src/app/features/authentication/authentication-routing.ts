import { FeatureRoutingModel } from '../../core/models/feature-routing.model';
import { ForgetPasswordComponent } from './presentation/forget-password/forget-password.component';
import { LoginComponent } from './presentation/login/login.component';
import { SignUpComponent } from './presentation/signup/signup.component';

const parentRoute: string = "auth";

enum RouteKeys{
    login="login",
    signup="signup",
    forgetPassword="forgetPassword",
}

export const authenticationRoutingObject: FeatureRoutingModel<RouteKeys> = {
    parentRoute: parentRoute,
    routes: {
        [RouteKeys.login]: {
            routingObject: {
                path: RouteKeys.login,
                component: LoginComponent
            },
            label: {
                label_en: 'login',
                label_ar: 'تسجيل الدخول'
            },
            parentRoute: parentRoute
        },
        [RouteKeys.signup]: {
            routingObject: {
                path: RouteKeys.signup,
                component: SignUpComponent
            },
            label: {
                label_en: 'signup',
                label_ar: 'تسجيل مستخدم جديد'
            },
            parentRoute: parentRoute
        },
        [RouteKeys.forgetPassword]: {
            routingObject: {
                path: RouteKeys.forgetPassword,
                component: ForgetPasswordComponent
            },
            label: {
                label_en: 'forget password',
                label_ar: 'نسيت كلمة المرور'
            },
            parentRoute: parentRoute
        }
    }

};