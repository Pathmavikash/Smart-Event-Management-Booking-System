export interface EventDTO {
  id: number;
  title: string;
  description: string;
  date: string | Date;
  venue: string;
  capacity: number;
  organizerId: number;
  price: number;
}