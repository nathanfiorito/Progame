import { Component, OnInit } from '@angular/core';
import { MediaObserver } from '@angular/flex-layout';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  view: string = 'dashboard';
  device!: string;

  constructor(private mediaObserver: MediaObserver) { }

  ngOnInit(): void {
    this.mediaObserver.asObservable().subscribe((change) => {
      this.device = change[0].mqAlias;
    })
  }

  public ToggleView(view: any): void{
    this.view = view;
  }

  public isDeviceMd(): boolean{
    if(this.device === 'sm' || this.device === 'xs'|| this.device === 'md')
      return true;
    else
     return false;
  }

}
