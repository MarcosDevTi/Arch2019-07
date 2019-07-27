import { AuthService } from './../../shared/auth.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  constructor(
    private fb: FormBuilder,
    private authService: AuthService
    ) { }

  ngOnInit() {
    this.buildRegisterForm();
  }

  buildRegisterForm() {
    this.registerForm = this.fb.group({
      username: [null, [Validators.required]],
      password: [null, [Validators.required]],
      email: [null, [Validators.required]],
    });
  }

  register() {
    this.authService.register(this.registerForm.value).subscribe(
      () => console.log('registration successful'),
      error => console.log(error));
  }
}
