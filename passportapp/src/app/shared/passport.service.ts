import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Passport } from './passport.model';
@Injectable({
  providedIn: 'root'
})
export class PassportService {

  ppData:Passport=new Passport();
  readonly ppApiUrl='http://localhost:5044/api/Passports';
  ppList:Passport[];

  constructor(private objHttp:HttpClient) {

   }
   
   postPassport()
   {
    return this.objHttp.post(this.ppApiUrl,this.ppData);
   }
   getPassportList()
   {
    this.objHttp.get(this.ppApiUrl).toPromise().then(res=>this.ppList=res as Passport[]);
    

   }
   delPassport(id)
   {
    return this.objHttp.delete(this.ppApiUrl+"/"+id);
   }
   putPassport()
   {
    return this.objHttp.put(this.ppApiUrl+"/"+this.ppData.Id,this.ppData);
   }
   
}