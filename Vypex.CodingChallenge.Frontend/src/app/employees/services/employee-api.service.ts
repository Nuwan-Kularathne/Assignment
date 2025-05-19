import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';

@Injectable({ providedIn: 'root' })
export class EmployeeApiService {
  private readonly httpClient = inject(HttpClient);

  private readonly baseUrl = 'https://localhost:7189/api';

  public getEmployees(name: string = ''): Observable<Array<Employee>> {
    return this.httpClient.get<Array<Employee>>(
      `${this.baseUrl}/employees?name=${name}`
    );
  }

  public createLeave(employeeId: string, startDate: string, endDate: string) {
    return this.httpClient.post(`${this.baseUrl}/employees/leave`, {
      employeeId: employeeId,
      startDate: startDate,
      endDate: endDate,
    });
  }

  public updateLeave(leaveId: string, startDate: string, endDate: string) {
    return this.httpClient.put(`${this.baseUrl}/employees/leave`, {
      leaveDayId: leaveId,
      newStartDate: startDate,
      newEndDate: endDate,
    });
  }

  public deleteLeave(leaveId: string) {
    return this.httpClient.delete(`${this.baseUrl}/employees/leave/${leaveId}`);
  }
}
