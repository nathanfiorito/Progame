import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  title: string = "Progame Home";

  constructor(private router: Router){

  }

  ngOnInit(): void {
  
  }

  public redirectTo(route: string): void {
    this.router.navigate([route]);
  }

}
