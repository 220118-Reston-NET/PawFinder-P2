import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NavbarService } from '../services/navbar.service';
import { PawfinderService } from '../services/pawfinder.service';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

 
constructor(private router:ActivatedRoute , private PawService:PawfinderService, public nav: NavbarService) {}
 
//  Chat()
//     {
//       this.router.navigate(["/chat"]);
//     }
    ngOnInit(): void {
      this.nav.show();
    // this.userName = this.router.snapshot.paramMap.get("userName");
    // this.PawService.getAllUsers(this.userName).subscribe(result=>{
    //   this.Users=result;
    // });
  }
}
