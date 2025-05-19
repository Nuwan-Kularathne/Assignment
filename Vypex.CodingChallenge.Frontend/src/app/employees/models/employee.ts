import { LeaveDay } from './leave-day';

export interface Employee {
  id: string;
  name: string;
  totalLeaveDays: number;
  leaveDays: LeaveDay[];
}
