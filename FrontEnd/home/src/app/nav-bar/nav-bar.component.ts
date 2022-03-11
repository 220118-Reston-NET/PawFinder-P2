import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavbarService } from '../services/navbar.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  constructor(private router:Router, public nav: NavbarService) { }

  ngOnInit(): void {
  }

  goToProfile()
  {
     this.router.navigate(["/profile"]);
  }
  
}

