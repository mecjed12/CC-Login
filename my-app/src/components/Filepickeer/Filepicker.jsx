import React from 'react';
import './Filepicker.css';

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
    render() {
        return(
            <div className="file-container">
                <label>Upload your file !</label>
                <input type="file" name="file" onChange={this.onChangeHandler}/>
            </div>
            
            
            
            
        )
    }
}