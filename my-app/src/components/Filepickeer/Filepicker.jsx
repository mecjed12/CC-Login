import React from 'react';
import './Filepicker.css';
import axios from 'axios';

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
        axios.post("http://localhost:3000", data,{
            
        })
        .then(res => {
            console.log(res.statusText)
        })
        
    }

    render() {
        return(
            <div className="file-container">
                <label>Upload your file !</label>
                <div className="upload-container">
                <input  className="upload" type="file" name="file" onChange={this.onChangeHandler}/>
                </div>
                <div className="button-container">
                <button type="button" className="button-click" onClick={this.onClickHandler}>Upload</button>
                </div>

            </div>
            
            
            
            
        )
    }
}