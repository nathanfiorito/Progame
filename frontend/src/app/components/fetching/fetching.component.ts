import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-fetching',
  templateUrl: './fetching.component.html',
  styleUrls: ['./fetching.component.scss']
})
export class FetchingComponent implements OnInit {

  @Input() isFetching: boolean = false;

  constructor() { }

  ngOnInit(): void {
  }

}
