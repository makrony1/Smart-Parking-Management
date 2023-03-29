import { Component } from '@angular/core';
import {AppService} from './app.service';
import { CheckinRequest, CheckinResponse, CheckoutRequest,CheckoutResponse, Report } from './model/model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'MyApp';

  checkoutPlate:string='';
  checkinPlate:string='';
  report:Report={
    availableParking:[],
    taotalEarning:{
      dateFrom:"",
      dateTo:"",
      total:0
    },
    totalParked:0
  };

  totalAvailable:number=0;

  constructor(
    private service: AppService,
  ) {}

  ngOnInit(): void {
    this.loadReport();
  }

  checkinClick():void{
    if(this.checkinPlate.trim().length<1){
      alert("Please enter the checkin License plate")
      return;
    }

    let body: CheckinRequest={
      plateNo:this.checkinPlate.trim(),
      vehicleType:"Sedan"
    };

    this.service.checkin(body).subscribe(
      (data)=>{
        alert("Checkin Sucess: "+data.parkingSpot);
        this.checkinPlate="";
        this.loadReport();
      },
      (error)=>{
        alert("Failed");
        console.log(error);
      }
    )

  }

  loadReport():void{
    this.service.getReport().subscribe(
      (data)=>{
        this.report=data;
        let sum = data.availableParking.map(t=>t.count).reduce((a, b) => a + b, 0);
        this.totalAvailable=sum;

      }
    )
  }
  checkoutClick():void{
    if(this.checkoutPlate.trim().length<1){
      alert("Please enter the checkin License plate")
      return;
    }
    let body: CheckoutRequest={
      plateNo:this.checkoutPlate.trim()
    };

    this.service.checkout(body).subscribe(
      (data)=>{
        console.log(data);
        if(data.success){
          alert("Checkout Sucess: "+data.message);
          this.checkoutPlate="";
          this.loadReport();
        }else{
          alert("Checkout Failed: "+data.message);
        }
        
      },
      (error)=>{
        alert("Failed");
        console.log(error);
      }
    )
  }
}
