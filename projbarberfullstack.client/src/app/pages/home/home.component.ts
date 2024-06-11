import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../../services/scheduleService/schedule.service';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit{

  schedules: Schedule[] = [];
  schedulesGeneral: Schedule[] = [];
  constructor(private scheduleService: ScheduleService) { }

  ngOnInit(): void {
    this.scheduleService.getSchedule().subscribe(scheduleData => {
      const dataList = scheduleData.data;

      dataList.map((item) => {
        console.log(item);
      })
    });
  }

}
