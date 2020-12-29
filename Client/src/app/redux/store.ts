import { AppState } from './app-state';
import { reducer } from './reducer';
import { createStore } from "redux";

export const store = createStore(reducer, new AppState());