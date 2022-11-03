import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { ResponseBase } from 'src/app/shared/models/responseBase.dto';
import { SignInDTO } from 'src/app/shared/models/user/signin.dto';
import { UserService } from 'src/app/shared/services/user/user.service';
import Utils from 'src/app/shared/utils/utils';

@Component({
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {
  errors: string[] = [];
  device!: string;
  signInForm!: FormGroup;
  isPasswordVisible: boolean = false;
  isFetching: boolean = false;
  
  constructor(
    private userService: UserService,
    private formBuilder: FormBuilder,
    private mediaObserver: MediaObserver,
    private cookieService: CookieService,
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
        password: ['', [Validators.required, Validators.minLength(8)]],
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

  public async SubmitForm(){
    const signInDTO: SignInDTO = {
      username: this.signInForm.get('username')!.value, 
      password: this.signInForm.get('password')!.value, 
    }

    this.errors = [];
    this.ToggleIsFetching();
    this.userService.SignIn(signInDTO).subscribe((res: ResponseBase) => {
      this.ToggleIsFetching()
      if(res.StatusCode === HttpStatusCode.Ok){
        this.cookieService.set('accessToken',res.Data)
        this.RedirectTo('dashboard');
      }
      else{
        alert(res.Mensagem)
      }
    },(err) => {
      this.ToggleIsFetching()
      this.errors = Utils.getErros(err);
    });
  }

  private ToggleIsFetching(){
    this.isFetching = !this.isFetching;
  }

  public RedirectTo(route: string): void {
    this.router.navigate([route]);
  }
}
