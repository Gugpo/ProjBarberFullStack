import { Component, OnInit } from '@angular/core';
import { ScheduleService } from '../../services/scheduleService/schedule.service';
import { Schedule } from '../../models/Schedule';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  schedules: Schedule[] = [];
  schedulesGeneral: Schedule[] = [];
  constructor(private scheduleService: ScheduleService) { }

  ngOnInit(): void {
    this.scheduleService.GetSchedule().subscribe(scheduleData => {
      const dataList = scheduleData.data;

      dataList.map((item) => {
        item.creationDate = new Date(item.creationDate).toLocaleDateString('pt-BR');
        item.changeDate = new Date(item.changeDate).toLocaleDateString('pt-BR');
      })

      this.schedules = scheduleData.data;
      this.schedulesGeneral = scheduleData.data;


    });
  }

}
