import { Component, Input, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { UserService } from 'src/app/shared/services/user/user.service';
import jwt_decode from 'jwt-decode';
import { Token } from 'src/app/shared/entities/token.entity';

@Component({
  selector: 'app-progress-bar',
  templateUrl: './progress-bar.component.html',
  styleUrls: ['./progress-bar.component.scss']
})
export class ProgressBarComponent implements OnInit {
  @Input() experience!: number;
  @Input() logo!: boolean;
  token!: Token;
  level!: number;
  barPercentage!: string;

  constructor(private userService: UserService,
    private cookieService: CookieService) { }

  ngOnInit(): void {
    this.DecryptToken();
      this.userService.GetUserInfo(this.token.id).subscribe((response) => {
        this.experience = response.Data.Experience;
        this.GetExp();
      })
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

  private GetExp(){
    this.CalculateUserExp(this.experience);
    this.barPercentage = this.experience.toString();
  }

  private CalculateUserExp(exp: number){
    this.experience = exp % 100;
    this.level = Math.round(exp / 100);
  }

}
