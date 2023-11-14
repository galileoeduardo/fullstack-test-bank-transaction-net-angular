export interface Transaction {
  id: number,
  description: string,
  date: Date,
  value: number,
  doubtful: boolean,
  status: Status
}

enum Status {
  Valid,
  Canceled
}
