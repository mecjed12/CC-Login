import React from 'react';
import './upload.css';
import axios from 'axios';

export default class Fileinput extends React.Component {
    onClickHandler = () => {
        const data = new FormData()
        data.append('file', this.state.selectedFile)
        
    }
   
    render() {
        return (
            <button type="button" className="button-click" onClick={this.onClickHandler}>Upload</button>
        )
    }
}