//using UnityEngine;
//using System.Collections.Generic;
//public class VirtualButtonEventHandler : MonoBehaviour,
//                                         IVirtualButtonEventHandler
//{
//	private GameObject Laguna_Obj;
//    private GameObject Squall_Obj;
//	private GameObject Seifer_Obj;
//	private GameObject Odin_Obj;
//	private GameObject Dragon_Obj;
//	
//	private GameObject Laguna_inf;
//    private GameObject Squall_inf;
//	private GameObject Seifer_inf;
//	private GameObject Odin_inf;
//	private GameObject Dragon_inf;
//	
//	private GameObject Laguna_Obj_Body;
//    private GameObject Squall_Obj_Body;
//	private GameObject Seifer_Obj_Body;
//	private GameObject Odin_Obj_Body;
//	private GameObject Dragon_Obj_Body;
//	
//	public Vector3 Laguna_Pos;
//	public Vector3 Squall_Pos;
//	public Vector3 Seifer_Pos;
//	public Vector3 Odin_Pos;
//	public Vector3 Dragon_Pos;
//	
//	public Quaternion Laguna_Rot;
//	public Quaternion Squall_Rot;
//	public Quaternion Seifer_Rot;
//	public Quaternion Odin_Rot;
//	public Quaternion Dragon_Rot;
//	
//	public Vector3 Laguna_inf_Pos;
//	public Vector3 Squall_inf_Pos;
//	public Vector3 Seifer_inf_Pos;
//	public Vector3 Odin_inf_Pos;
//	public Vector3 Dragon_inf_Pos;
//	
//	
//	
//	private bool ActiveState = false;
//	
//    void Start()
//    {
//        
//        VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
//        for (int i = 0; i < vbs.Length; ++i)
//        {
//            vbs[i].RegisterEventHandler(this);
//        }
//		
//		Laguna_Obj = GameObject.Find("Laguna");
//		Squall_Obj = GameObject.Find("Squall");
//		Seifer_Obj = GameObject.Find("Seifer");
//		Odin_Obj = GameObject.Find("Odin");
//		Dragon_Obj = GameObject.Find("RubyDragon");
//		
//		Laguna_inf = Laguna_Obj.transform.Find("Laguna_Info_head").gameObject;
//		Squall_inf = Squall_Obj.transform.Find("Squall_Info_head").gameObject;
//		Seifer_inf = Seifer_Obj.transform.Find("Seifer_Info_head").gameObject;
//		Odin_inf = Odin_Obj.transform.Find("Odin_Info_head").gameObject;
//		Dragon_inf = Dragon_Obj.transform.Find("RubyDragon_Info_head").gameObject;
//		
//		Laguna_Obj_Body = Laguna_Obj.transform.Find("LagunaBody").gameObject;
//		Squall_Obj_Body = Squall_Obj.transform.Find("SquallBody").gameObject;
//		Seifer_Obj_Body = Seifer_Obj.transform.Find("SeiferBody").gameObject;
//		Odin_Obj_Body = Odin_Obj.transform.Find("OdinBody").gameObject;
//		Dragon_Obj_Body = Dragon_Obj.transform.Find("RBhead").gameObject;
//		
//		Laguna_Obj.active = true;
//		Laguna_inf.active = false;
//		Squall_Obj.active = false;
//		Seifer_Obj.active = false;
//		Odin_Obj.active = false;
//		Dragon_Obj.active = false;
//		
//		Laguna_Pos = Laguna_Obj_Body.transform.position;
//		Squall_Pos = Squall_Obj_Body.transform.position;
//		Seifer_Pos = Seifer_Obj_Body.transform.position;
//		Odin_Pos = Odin_Obj_Body.transform.position;
//		Dragon_Pos = Dragon_Obj_Body.transform.position;
//		
//		Laguna_Rot = Laguna_Obj_Body.transform.rotation;
//		Squall_Rot = Squall_Obj_Body.transform.rotation;
//		Seifer_Rot = Seifer_Obj_Body.transform.rotation;
//		Odin_Rot = Odin_Obj_Body.transform.rotation;
//		Dragon_Rot = Dragon_Obj_Body.transform.rotation;
//		
//		Laguna_inf_Pos = Laguna_inf.transform.position;
//		Squall_inf_Pos = Squall_inf.transform.position;
//		Seifer_inf_Pos = Seifer_inf.transform.position;
//		Odin_inf_Pos = Odin_inf.transform.position;
//		Dragon_inf_Pos = Dragon_inf.transform.position;
//		
//    }
//	
//    public void OnButtonPressed(VirtualButtonBehaviour vb)
//    {
//        
//        switch (vb.VirtualButtonName)
//        {
//            case "Laguna_Button":
//				Laguna_Obj.active = !(Laguna_Obj.active) ;
//				Laguna_inf.active = ActiveState;
//				Squall_Obj.active = false;
//				Seifer_Obj.active = false;
//				Odin_Obj.active = false;
//				Dragon_Obj.active = false;
//                break;
//				
//			case "Squall_Button":
//				Squall_Obj.active = !(Squall_Obj.active) ;
//				Squall_inf.active = ActiveState;
//				Laguna_Obj.active = false;
//				Seifer_Obj.active = false;
//				Odin_Obj.active = false;
//				Dragon_Obj.active = false;
//                break;
//				
//			case "Seifer_Button":
//				Seifer_Obj.active = !(Seifer_Obj.active) ;
//				Seifer_inf.active = ActiveState;
//				Squall_Obj.active = false;
//				Laguna_Obj.active = false;
//				Odin_Obj.active = false;
//				Dragon_Obj.active = false;
//                break;
//				
//			case "Odin_Button":
//				Odin_Obj.active = !(Odin_Obj.active) ;
//				Odin_inf.active = ActiveState;
//				Squall_Obj.active = false;
//				Seifer_Obj.active = false;
//				Laguna_Obj.active = false;
//				Dragon_Obj.active = false;
//                break;
//				
//			case "RubyDragon_Button":
//				Dragon_Obj.active = !(Dragon_Obj.active) ;
//				Dragon_inf.active = ActiveState;
//				Squall_Obj.active = false;
//				Seifer_Obj.active = false;
//				Odin_Obj.active = false;
//				Laguna_Obj.active = false;
//                break;
//			
//			case "Info_Button":
//				ActiveState = !(ActiveState);
//				Laguna_inf.active = ActiveState;
//				Squall_inf.active = ActiveState;
//				Seifer_inf.active = ActiveState;
//				Odin_inf.active = ActiveState;
//				Dragon_inf.active = ActiveState;
//                break;
//			
//			case "Reset_Button":
//				Laguna_Obj_Body.transform.position = Laguna_Pos;
//				Squall_Obj_Body.transform.position = Squall_Pos;
//				Seifer_Obj_Body.transform.position = Seifer_Pos;
//				Odin_Obj_Body.transform.position = Odin_Pos;
//				Dragon_Obj_Body.transform.position = Dragon_Pos;
//			
//				Laguna_inf.transform.position = Laguna_inf_Pos;
//				Squall_inf.transform.position = Squall_inf_Pos;
//				Seifer_inf.transform.position = Seifer_inf_Pos;
//				Odin_inf.transform.position = Odin_inf_Pos;
//				Dragon_inf.transform.position = Dragon_inf_Pos;
//			
//				Laguna_Obj_Body.transform.rotation = Laguna_Rot;
//				Squall_Obj_Body.transform.rotation = Squall_Rot;
//				Seifer_Obj_Body.transform.rotation = Seifer_Rot;
//				Odin_Obj_Body.transform.rotation = Odin_Rot;
//				Dragon_Obj_Body.transform.rotation = Dragon_Rot;
//			
//				break;
//
//        }
//
//    }
//
//    public void OnButtonReleased(VirtualButtonBehaviour vb)
//    {
//		return;
//	}
//}