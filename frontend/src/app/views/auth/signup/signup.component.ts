import { Component, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { passwordMatch } from '../../../shared/utils/validators/password.validators'

@Component({
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  device!: string;
  signInForm!: FormGroup;
  isPasswordVisible: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private mediaObserver: MediaObserver,
    private router: Router
   ) { }
   
   
  ngOnInit(): void {
    this.InitForm();
    this.mediaObserver.asObservable().subscribe((change) => {
      this.device = change[0].mqAlias;
    })
  }
    
  private InitForm(){
      this.signInForm = this.formBuilder.group({
        username: ['', [Validators.required, Validators.minLength(4)]],
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(8), Validators.pattern('((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$')]],
        passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.pattern('((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$')]]
      },{
        validator: passwordMatch('password', 'passwordConfirm')
      })
  }

  public TogglePasswordVisibility(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  public IsDeviceSm(): boolean{
    if(this.device === 'sm' || this.device === 'xs')
      return true;
    else
      return false;
  }

  public SubmitForm(){

  }

  public RedirectTo(route: string): void {
    this.router.navigate([route]);
  }
}
