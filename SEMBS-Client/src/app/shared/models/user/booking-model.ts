export interface BookingDTO {
  userName: string;
  eventName: string;
  date: string | Date;
  venue: string;
  capacity: number;
  organizerId: number;
  price: number;
}