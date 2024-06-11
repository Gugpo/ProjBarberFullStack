import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ScheduleService {

  private apiUrl = '${environment.ApiUrl}/schedule';
  constructor(private http: HttpClient) { }
}
