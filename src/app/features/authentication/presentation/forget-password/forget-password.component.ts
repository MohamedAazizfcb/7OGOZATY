import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ForgetPasswordPresenter } from './forget-password.presenter';
import { CommonModule } from '@angular/common';
import { LoggerService } from '../../../../core/services/logger.service';

@Component({
  selector: 'app-forget-password',
  standalone: true,
  templateUrl: './forget-password.component.html',
  styleUrls: ['./forget-password.component.scss'],
  imports: [CommonModule, ReactiveFormsModule],
  providers: [ForgetPasswordPresenter],
})
export class ForgetPasswordComponent {
  forgetPasswordForm: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private presenter: ForgetPasswordPresenter,
    private logService: LoggerService,
   ) 
    {
      this.forgetPasswordForm = this.fb.group({
        email: ['', [Validators.required, Validators.email]]
      });
    }

  onSubmit() {
    if (this.forgetPasswordForm.valid) {
      this.logService.info(`user ${this.forgetPasswordForm.value.email} is trying to update the password`);
      this.presenter.forgetPassword(this.forgetPasswordForm.value.email)
        .subscribe(response => {
          this.logService.info(`user ${this.forgetPasswordForm.value.email} updated the password successfully!`);
        });
    }
  }
}