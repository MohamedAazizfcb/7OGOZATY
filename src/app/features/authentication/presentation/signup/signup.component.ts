import { Component, Inject, PLATFORM_ID } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { SignUpPresenter } from './signup.presenter';
import { CommonModule, isPlatformBrowser } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { LoggerService } from '../../../../core/services/logger.service';

@Component({
  selector: 'app-signup',
  standalone: true,
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
  imports: [CommonModule, ReactiveFormsModule ],
  providers: [SignUpPresenter],
})
export class SignUpComponent {
  signupForm: FormGroup;

  constructor(
    private fb: FormBuilder, 
    private presenter: SignUpPresenter,
    private logService: LoggerService,
    @Inject(PLATFORM_ID) private platformId: Object

  ) {
    this.signupForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.signupForm.valid) {
      if (isPlatformBrowser(this.platformId)) {
        // Ensure this code only runs in the browser
        this.logService.info(`Trying to create a new user ${ this.signupForm.value.username }`);
        this.presenter.signup(this.signupForm.value.username, this.signupForm.value.password, this.signupForm.value.email)
          .subscribe(response => {
            // Handle successful signup
            this.logService.info(`User ${ this.signupForm.value.username } is created successfully`);
          });
      }
    }
  }
}