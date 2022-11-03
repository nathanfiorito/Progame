import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ResponseBase } from '../../models/responseBase.dto';
import { SignInDTO } from '../../models/user/signin.dto';
import { SignUpDTO } from '../../models/user/signup.dto';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient
    ) { }

    httpOptions = {
      headers: new HttpHeaders({
        'content-type': 'application/json',
        'observe':'body',
        'responseType': 'json',
        'Access-Control-Allow-Origin': '*'
      })
    }

    public SignIn(signinDTO: SignInDTO): Observable<ResponseBase>{
      let body = JSON.stringify(signinDTO);
      return this.http.post<ResponseBase>(`${environment.apiURL}/auth/signin`, body, this.httpOptions)
    }

    public SignUp(signupDTO: SignUpDTO): Observable<ResponseBase>{
      let body = JSON.stringify(signupDTO);
      return this.http.post<ResponseBase>(`${environment.apiURL}/auth/signup`, body, this.httpOptions)
    }

    public GetUserInfo(currentUserId: number): Observable<ResponseBase>{
      return this.http.get<ResponseBase>(`${environment.apiURL}/auth/GetUserInfo?Id=${currentUserId}`, this.httpOptions)
    }
}
