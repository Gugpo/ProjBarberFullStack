import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private apiUrl = '${http://localhost:3000/api/schedule}';
  constructor(private http: HttpClient) { }
}
