import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { PassportService } from 'src/app/shared/passport.service';

@Component({
  selector: 'app-reg',
  templateUrl: './reg.component.html',
  styleUrls: ['./reg.component.css']
})
export class RegComponent implements OnInit {

  constructor(public objservice:PassportService) {

  }

 ngOnInit() {
   this.resetForm();
   
 }
 resetForm(form?:NgForm)
 {
   if(form!=null)
  { form.form.reset();}
  else
  {
 
     this.objservice.ppData={Id:0,HolderName:'',PassportNumber:'',Expiry:'',  POCode:''}
}
}
onSubmit(form:NgForm)
{
  if(this.objservice.ppData.Id==0)
  {this.insertRecord(form);}
  else{
    this.updateRecord(form);
  }
}
   insertRecord(form:NgForm)
   {
     this.objservice.postPassport().subscribe(res=>
      {this.resetForm(form);
      this.objservice.getPassportList();
      alert('Passport Registeration Success!!!');
    },
      err=>{alert('Error!!!'+err);})
   }
updateRecord(form:NgForm)
{
  this.objservice.putPassport().subscribe(
    res=>{
      this.resetForm();
      this.objservice.getPassportList();
      alert('Passport Record updated!!!');
    },
    err=>{
      alert('Error!!!'+err);
    }
  )
}

  }
