import { HttpStatusCode } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Token } from 'src/app/shared/entities/token.entity';
import { User } from 'src/app/shared/entities/user/user.entity';
import { ResponseBase } from 'src/app/shared/models/responseBase.dto';
import { UserService } from 'src/app/shared/services/user/user.service';
import Utils from 'src/app/shared/utils/utils';
import jwt_decode from 'jwt-decode';
import { MediaObserver } from '@angular/flex-layout';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
  @Output() viewEvent = new EventEmitter<string>();
  errors: string[] = [];
  device!: string;
  user!: User;
  token!: Token;
  isFetching: boolean = false;
  view: string = 'dashboard';

  constructor(
    private cookieService: CookieService,
    private userService: UserService,
    private mediaObserver: MediaObserver,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.DecryptToken();
    this.GetUserInfo();
    this.mediaObserver.asObservable().subscribe((change) => {
      this.device = change[0].mqAlias;
    })
  }

  public ToggleView(view: string){
    this.view = view;
    this.viewEvent.emit(view);
  }

  private async GetUserInfo(){
    await this.userService.GetUserInfo(this.token.id).subscribe((res: ResponseBase) => {
      this.user = res.Data
    },(err) => {

    });
  }

  public isDeviceMd(): boolean{
    if(this.device === 'sm' || this.device === 'xs'|| this.device === 'md')
    return true;
    else
    return false;
  }
  
  public isDeviceSm(): boolean{
    if(this.device === 'sm' || this.device === 'xs')
      return true;
    else
      return false;
  }

  private DecryptToken(){
    this.token = this.getDecodedAccessToken();
  }

  private getDecodedAccessToken(): any {
    try {
      return jwt_decode(this.cookieService.get('accessToken'));
    } catch(error) {
      return null;
    }
  }

  private ToggleIsFetching(){
    this.isFetching = !this.isFetching;
  }

  public RedirectTo(route: string): void {
    this.router.navigate([route]);
  }
}
