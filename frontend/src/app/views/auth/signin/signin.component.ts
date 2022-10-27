import { Component, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {
  device!: string;
  signInForm!: FormGroup;
  isPasswordVisible: boolean = false;
  
  constructor(
    private formBuilder: FormBuilder,
    private mediaObserver: MediaObserver,
    private router: Router
   ) { }
   
   
  ngOnInit(): void {
    this.initForm();
    this.mediaObserver.asObservable().subscribe((change) => {
      this.device = change[0].mqAlias;
    })
  }
    
  private initForm(){
      this.signInForm = this.formBuilder.group({
        username: ['', [Validators.required, Validators.minLength(4)]],
        password: ['', [Validators.required, Validators.minLength(8), Validators.pattern('((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$')]],
        remember: ['']
      })
  }

  public togglePasswordVisibility(): void {
    this.isPasswordVisible = !this.isPasswordVisible;
  }

  public isDeviceSm(): boolean{
    if(this.device === 'sm' || this.device === 'xs')
      return true;
    else
      return false;
  }

  public submitForm(){

  }

  public redirectTo(route: string): void {
    this.router.navigate([route]);
  }
}
