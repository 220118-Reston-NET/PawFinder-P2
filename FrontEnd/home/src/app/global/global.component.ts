import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-global',
  templateUrl: './global.component.html',
  styleUrls: ['./global.component.css']
})
export class GlobalComponent implements OnInit {

  public static loggedInUserID:number = 0;
  public static loggedInUserName: string = "";
  
  public static chattingUserID:number = 0;

  constructor() { }

  ngOnInit(): void {
  }

}
