import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { EventDTO } from "../../shared/models/events/event-model";

@Injectable({ providedIn: 'root' })
export class EventService {
  // Update this to match your .NET API URL

// constructor(private http: HttpClient) { }

//   private apiUrl = 'https://localhost:44306/api/event';

//   register(req: RegisterRequest) {
//     return this.http.post(`${this.apiUrl}/register`, req);
//   }
//   login(request: LoginRequest) {
//     return this.http.post<any>(`${this.apiUrl}/login`, request);
//   }


  private apiUrl = 'https://localhost:44306/api/event'; 

  constructor(private http: HttpClient) {}

  getAllEvents(): Observable<EventDTO[]> {
    return this.http.get<EventDTO[]>(`${this.apiUrl}/getAllEvents`);
  }

  getMyEvents(userId: number): Observable<EventDTO[]> {
    return this.http.get<EventDTO[]>(`${this.apiUrl}/getMyEvents/${userId}`);
  }

  // Passing the DTO to match your .NET Post method
 createEvent(event: EventDTO) {
    return this.http.post(`${this.apiUrl}/create`, event);
  }

  // Update logic using the ID in the URL
  // updateEvent(event: EventDTO): Observable<any> {
  //   return this.http.put(`${this.apiUrl}/${event.id}`, event);
  // }

  // Added Delete method since your Repository supports it
  deleteEvent(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}