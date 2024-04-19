import { Component, OnInit } from '@angular/core';
import { PassportService } from 'src/app/shared/passport.service';

@Component({
  selector: 'app-diplay',
  templateUrl: './diplay.component.html',
  styleUrls: ['./diplay.component.css']
})
export class DiplayComponent implements OnInit {

  constructor(public objs:PassportService) { }

  ngOnInit(): void {
    this.objs.getPassportList();
  }
  fillForm(selectedPP)
  {
    this.objs.ppData=Object.assign({},selectedPP);
  }
  onDelete(pid)
  {
   if(confirm('Are you sure to delete this Passprot ?'))
   {
    this.objs.delPassport(pid).subscribe(
      res=>{this.objs.getPassportList()
      },
      err=>{alert("Error Occured "+err);
    }

    )
   }
  
  }
}
