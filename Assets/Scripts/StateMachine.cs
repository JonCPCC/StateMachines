using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
     {
          idle, 
          walking, 
          swimming, 
          climbing
     }

     public State currentState = State.idle;
     Vector3 lastPosition;

     // Start is called before the first frame update
     // Update is called once per frame
     void Start()
     {
          lastPosition = transform.position;
     }

     // Update is called once per frame
     void Update()
     {
          switch(currentState)
          {
               case State.idle: Idle();  break;
               case State.walking: Walking();  break;
               case State.climbing: Climbing(); break;
               case State.swimming: Swimming(); break;
               default: break;
          }
     }

     void OnTriggerEnter(Collider other)
     {
          if (other.name == "Water")
          {
               Debug.Log("I am swimming");
               currentState = State.swimming;
          }
          else if(other.name == "HillTop")
          {
               Debug.Log("I am climbing");
               currentState = State.climbing;
          }
     }

     void OnTriggerExit(Collider other)
     {
          Debug.Log("+Walking");
          currentState = State.walking;
     }
     void Swimming()
     {
          Debug.Log("I am swimming");
          currentState = State.swimming;
     }

     void Climbing()
     {
          Debug.Log("I am climbing");
          currentState = State.climbing;
     }

     void Idle()
     {
          if (lastPosition != transform.position) 
          {
               Debug.Log("Moving");
               currentState = State.walking;
          }
          else
          {
               Debug.Log("I am idle");
               currentState = State.idle;
          }
          lastPosition = transform.position;
     }

     void Walking()
     {
          
          if (lastPosition == transform.position)
          {
               Debug.Log("Stopped");
               currentState = State.idle;
          }
          else
          {
               Debug.Log("+Walking");
               currentState = State.walking;
          }
          lastPosition = transform.position;
     }
}
