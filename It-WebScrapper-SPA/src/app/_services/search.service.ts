import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchResult } from '../_models/searchResult';
import { SearchRequest } from '../_models/searchRequest';
import { Observable } from 'rxjs';

@Injectable()
export class searchService {

    baseUrl = 'http://localhost:5000/';

    constructor(private http: HttpClient) {
    }

    newSearch(keywords: string, url: string):Observable<SearchResult> {

        const payload: SearchRequest = {
            url,
            keywords
        };

        return this.http.post<SearchResult>(this.baseUrl + 'Search/Search', payload);
    }

    getSearchHistory(): Observable<SearchResult[]> {
        return this.http.get<SearchResult[]>(this.baseUrl + 'Search/History');
    }

}



