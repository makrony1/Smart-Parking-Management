export interface CheckinRequest {
    plateNo:string,
    vehicleType:string
  }
  export interface CheckoutRequest {
    plateNo:string
  }

  export interface CheckinResponse {
    parkingSpot:string
  }

  export interface CheckoutResponse {
    success:boolean,
    message:string
  }

  
  export interface Report{
    taotalEarning:Earnings,
    availableParking:ParkingByTypes[],
    totalParked:number
  }
export interface Earnings{
    dateFrom:string,
    dateTo:string,
    total:number
}
  export interface ParkingByTypes {
    type:string,
    count:number
  }