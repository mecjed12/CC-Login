import React from 'react';
import './Filepicker.css';
import axios from 'axios';
import Fileinput from '../input/Fileinput';

export default class Filepicker extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            selectFile: null,
        }
       
      }
    onChangeHandler=event=>{
       
        this.setState({
            selectFile: event.target.files[0],
            loaded: 0,
        });
        
    }
    

    onClickHandler = () => {
        const data = new FormData()
        data.append('file', this.state.selectFile)
        axios.post("https://localhost:44375/api/Registration", data, {
            
        })
        .then(res => {
            console.log(res.statusText)
        })
        
    }

    render() {
        return(
            <div className="file-container">
                <div className="upload-container">
                <label>Upload your file !</label>
                <input  className="upload" type="file" name="file" onChange={this.onChangeHandler}/>
                </div>
                <div type="button" className="button-click" onClick={this.onClickHandler}>Upload</div>
                <Fileinput/>
            </div>
            
            
            
            
        )
    }
}