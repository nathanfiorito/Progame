import { HttpStatusCode } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ResponseBase } from 'src/app/shared/models/responseBase.dto';
import { SignUpDTO } from 'src/app/shared/models/user/signup.dto';
import { UserService } from 'src/app/shared/services/user/user.service';
import Utils from 'src/app/shared/utils/utils';
import { passwordMatch } from '../../../shared/utils/validators/password.validators'

@Component({
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {
  errors: string[] = [];
  device!: string;
  signUpForm!: FormGroup;
  isPasswordVisible: boolean = false;
  isFetching: boolean = false;

  constructor(
    private userService: UserService,
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
      this.signUpForm = this.formBuilder.group({
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

  public async SubmitForm(){
    const signUpDTO: SignUpDTO = {
      email: this.signUpForm.get('email')!.value, 
      username: this.signUpForm.get('username')!.value, 
      password: this.signUpForm.get('password')!.value, 
      passwordConfirm: this.signUpForm.get('passwordConfirm')!.value
    }

    this.errors = [];
    this.ToggleIsFetching();
    this.userService.SignUp(signUpDTO).subscribe((res: ResponseBase) => {
      this.ToggleIsFetching()
      if(res.StatusCode === HttpStatusCode.Ok)
        this.RedirectTo('signin');
      else
        alert(res.Mensagem)
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

  private ShowErros(){
    this.errors.forEach(err => alert(err))
  }
}
