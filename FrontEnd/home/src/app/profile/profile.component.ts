import { Component, OnInit } from '@angular/core';
import { PawfinderService } from './../services/pawfinder.service';
import { Users } from './../models/users.model';
import { ActivatedRoute} from '@angular/router';
import { NavbarService } from '../services/navbar.service';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
 userName:string | null = "No users Selected";
// Users:PawfinderApi;
 Users: any;
  constructor(private router:ActivatedRoute, private PawService:PawfinderService, public nav: NavbarService) {
    this.Users={ sprites: {
      back_default:"",
      back_shiny:"",
      front_default:"",
      front_shiny:""
    }};
   }

  ngOnInit(): void {
    // this.userName = this.router.snapshot.paramMap.get("userName");
    // this.PawService.getAllUsers(this.userName).subscribe(result=>{
    //   this.Users=result;
    // });
    this.nav.show();
  }
  matchColorPinck()
  {
    return 
  }

}
