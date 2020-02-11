export class PaginatedResult<T>{
    hasNext: boolean;
    hasPrevious: boolean
    count: number
    entities: Array<T>
}

export class PageInfo {
    pageSize: number;
    pageNumber: number;
    orderBy : string;
    sortDirection : SortDirection
}

export enum SortDirection{
    Ascending,
    Descending
}